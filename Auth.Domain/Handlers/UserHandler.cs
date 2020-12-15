using Auth.Domain.Commands;
using Auth.Domain.Commands.UserCommands;
using Auth.Domain.Entities;
using Auth.Domain.Queries;
using Auth.Domain.Repositories;
using Auth.Domain.Services;
using Auth.Domain.Shared.Commands;
using Auth.Domain.Shared.Handlers;
using Auth.Domain.ValueObjects;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace Auth.Domain.Handlers
{
    public class UserHandler : Notifiable, 
        IHandler<CreateUserCommand>,
        IHandler<AuthenticateUserCommand>,
        IHandler<UpdateEmailUserCommand>,
        IHandler<UpdateNameUserCommand>,
        IHandler<UpdatePasswordUserCommand>,
        IHandler<UpdateRoleUserCommand>,
        IHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public UserHandler(IUserRepository repository, IEmailService emailService, ITokenService tokenService)
        {
            _repository = repository;
            _emailService = emailService;
            _tokenService = tokenService;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            //validar command
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //CheckUser
            if (_repository.CheckEmail(command.Email))
                AddNotification("Repository.CheckEmail", "Este e-mail já existe");

            //Criar VO'S
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var pass = new Password(command.Password);

            //Criar entidades
            var user = new User(name, email, pass);

            AddNotifications(name, email, pass, user);

            if(Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", Notifications);

            //Tarefas async
            var taskRepository = _repository.Save(user);
            _ = _emailService.SendWelcome(user);

            ////resultado das tarefas
            await taskRepository;

            ///CriandoToken
            var token = _tokenService.GenerateToken(user);

            user.Password.HidePassword();

            //Retorna valores
            return new GenericCommandResult(true, "Usário salvo com sucesso!", new { user, token });
        }
        public async Task<ICommandResult> Handle(AuthenticateUserCommand command)
        {
            //validar command
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //GetUser
            var user = _repository.GetUserByEmail(command.Email);

            if(user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            if (user.Password.Pass != command.Password)
                AddNotification("Password", "Senha incorreta");

            AddNotifications(user);
            if (Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", Notifications);

            ///CriandoToken
            var token = _tokenService.GenerateToken(user);

            user.Password.HidePassword();

            //Retorna valores
            return new GenericCommandResult(true, "Usuário autenticado", new { user, token });
        }
        public async Task<ICommandResult> Handle(UpdateEmailUserCommand command)
        {
            //validar command
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //CheckNewEmail
            if(_repository.CheckEmail(command.NewEmail))
                AddNotification("Check.Email", "Este e-mail já está cadastrado");

            //GetUser
            var user = _repository.GetUser(command.Id, command.Email);

            if(user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            //Criar VO's
            var email = new Email(command.NewEmail);
            AddNotifications(email);

            if(Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", Notifications);

            user.UpdateEmail(email);
            await _repository.Update(user);

            user.Password.HidePassword();
            //Retorna valores
            return new GenericCommandResult(true, "E-mail atualziado", new { user });

        }
        public async Task<ICommandResult> Handle(UpdateNameUserCommand command)
        {
            //validar command
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //GetUser
            var user = _repository.GetUser(command.Id, command.Email);

            if (user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            //Criar VO's
            var name = new Name(command.FirstName, command.LastName);
            AddNotifications(name);

            if (Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", Notifications);

            user.UpdateName(name);
            await _repository.Update(user);

            user.Password.HidePassword();
            //Retorna valores
            return new GenericCommandResult(true, "Nome atualizado", new { user });

        }
        public async Task<ICommandResult> Handle(UpdatePasswordUserCommand command)
        {
            //validar command
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //GetUser
            var user = _repository.GetUser(command.Id, command.Email);

            if (user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            //Criar VO's
            var pass = new Password(command.Password);
            AddNotifications(pass);

            if (Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", Notifications);

            user.UpdatePassword(pass);
            await _repository.Update(user);

            user.Password.HidePassword();
            //Retorna valores
            return new GenericCommandResult(true, "Senha atualizada", new { user });

        }
        public async Task<ICommandResult> Handle(UpdateRoleUserCommand command)
        {
            //validar command
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //GetUser
            var user = _repository.GetUser(command.Id, command.Email);

            if (user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            //Validar Role
            AddNotification("Handle.Role", "Não é possível atualizar o role ainda");

            if (Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", Notifications);

            user.UpdateRole(command.Role);
            await _repository.Update(user);

            user.Password.HidePassword();
            //Retorna valores
            return new GenericCommandResult(true, "Role atualizado", new { user });

        }
        public async Task<ICommandResult> Handle(DeleteUserCommand command)
        {
            //validar command
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, algo errado aconteceu!", command.Notifications);

            //GetUser
            var user = _repository.GetUser(command.Id, command.Email);

            if (user == null)
                return new GenericCommandResult(false, "Usuário não encontrado", null);

            await _repository.Delete(user);

            //Retorna valores
            return new GenericCommandResult(true, $"O usuário {user.Name} foi deletado com sucesso", null );

        }
    }
}