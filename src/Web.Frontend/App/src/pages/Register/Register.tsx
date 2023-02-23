import React from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";

import { Form } from "../../components/forms/Form";
import { Input } from "../../components/input/Input";
import { Wrap } from "../../components/wrap/Wrap";
import { Configuration, UserApi } from "../../services";

type TRegisterForm = {
  name: string;
  email: string;
  password: string;
  repeatPassword: string;
};

export const Register = () => {
  const { register, handleSubmit } = useForm();
  const navigate = useNavigate();

  const onSubmit: SubmitHandler<TRegisterForm> = async (data) => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const userApi = new UserApi(config);

    const result = await userApi.apiUserPost({
      accountMode: 0,
      dateOfBirth: new Date(),
      email: data.email,
      name: data.name,
      password: data.password,
    });

    if (result.status === 200) {
      navigate("/login");
    }
  };

  return (
    <Wrap title="Регистрация" centered>
      <Form
        rightIcon="userAdd"
        rightLabel="Регистрация"
        leftIcon="key"
        leftLabel="Войти"
        leftClick={() => navigate("/login")}
        onSubmit={handleSubmit(onSubmit)}
      >
        <Input
          icon="user"
          label="Имя пользователя"
          placeholder="Иванов Иван"
          {...register("name", { required: true })}
        />
        <Input
          icon="at"
          label="Почта"
          placeholder="ivanov@mail.ru"
          {...register("email", { required: true })}
        />
        <Input
          icon="password"
          label="Пароль"
          placeholder="password1234"
          {...register("password", { required: true })}
        />
        {/* <Input
          icon="password"
          label="Повтор пароля"
          placeholder="password1234"
          {...register("repeatPassword", { required: true })}
        /> */}
      </Form>
    </Wrap>
  );
};
