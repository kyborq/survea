import React, { useState } from "react";

import { Logo } from "../Logo/Logo";
import { Avatar } from "../Avatar/Avatar";
import { Button } from "../Button/Button";

import styles from "./Header.module.css";

import { LoginForm } from "../../forms/LoginForm";
import { RegisterForm } from "../../forms/RegisterForm";
import { useAppSelector } from "../../store/store";
import { useNavigate } from "react-router-dom";

export const Header = () => {
  const [loginModal, setLoginModal] = useState(false);
  const [registerModal, setRegisterModal] = useState(false);

  const navigate = useNavigate();

  const logged = useAppSelector((s) => s.user.logged);

  return (
    <div className={styles.Header}>
      <div className={styles.Container}>
        <Logo />

        <div className={styles.Actions}>
          <div className={styles.Buttons}>

            {logged && (
              <Button
                label="Опрос"
                icon="addCircle"
                primary
                onClick={() => {
                  navigate("/constructor");
                }}
              />
            )}
            {!logged && (
              <Button
                label="Регистрация"
                icon="addCircle"
                onClick={() => setRegisterModal(true)}
              />
            )}
          </div>

          <Avatar onAuth={() => setLoginModal(true)} />
        </div>
      </div>

      {loginModal && <LoginForm onClose={() => setLoginModal(false)} />}
      {registerModal && (
        <RegisterForm onClose={() => setRegisterModal(false)} />
      )}
    </div>
  );
};
