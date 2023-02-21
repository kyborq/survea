import React from "react";
import { SubmitHandler, useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";

import { Form } from "../../components/forms/Form";
import { Input } from "../../components/input/Input";
import { Wrap } from "../../components/wrap/Wrap";
import { LoginApi, UserApi } from "../../services/api";
import { Configuration } from "../../services/configuration";

type TLoginForm = {
  email: string;
  password: string;
};

export const Login = () => {
  const { register, handleSubmit } = useForm();
  const navigate = useNavigate();

  const onSubmit: SubmitHandler<TLoginForm> = async (data) => {
    const config = new Configuration({
      basePath: "https://localhost:5001/",
    });

    const loginApi = new LoginApi(config);

    const result = await loginApi.apiLoginPost({
      email: data.email,
      password: data.password,
    });

    console.log(result);

    if (result.status === 200) {
      navigate("/");
    }
  };

  return (
    <Wrap title="Войти" centered>
      <Form
        rightIcon="key"
        rightLabel="Войти"
        leftIcon="userAdd"
        leftLabel="Регистрация"
        leftClick={() => navigate("/register")}
        onSubmit={handleSubmit(onSubmit)}
      >
        <Input
          icon="at"
          label="Электронная почта"
          placeholder="ivanov@mail.ru"
          {...register("email", { required: true })}
        />
        <Input
          icon="password"
          label="Пароль"
          placeholder="password1234"
          {...register("password", { required: true })}
        />
      </Form>
    </Wrap>
  );
};
