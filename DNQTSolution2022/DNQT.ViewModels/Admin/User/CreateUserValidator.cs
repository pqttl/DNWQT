using FluentValidation;

namespace DNQT.ViewModels.Admin.User
{
    public class CreateUserValidator : AbstractValidator<CreateUser_ViewModel>
    {
        public CreateUserValidator()
        {
            {
                string strMess = "Tên đăng nhập và mật khẩu mới phải từ 7 kí tự trở lên!";
                RuleFor(x => x.StrUserNameAndPass).NotEmpty()
                    .WithMessage(strMess)
                    .MinimumLength(6)
                    .WithMessage(strMess);
            }

            {
                string strMess = "Mật khẩu của superadmin(q...3) không chính xác!";
                RuleFor(x => x.StrPasswordSuperadmin)
                    .NotEmpty()
                    .WithMessage(strMess)
                    .Must(x => x == "quoctuan931113")
                    .WithMessage(strMess);
            }
        }
    }
}
