import React, { useState } from "react";

import { Logo } from "../Logo/Logo";
import { Avatar } from "../Avatar/Avatar";
import { Button } from "../Button/Button";

import styles from "./Header.module.css";
import { Modal } from "../Modal/Modal";
import { Input } from "../Input/Input";

export const Header = () => {
  const [surveyModal, setSurveyModal] = useState(false);

  return (
    <div className={styles.Header}>
      <div className={styles.Container}>
        <Logo />

        <div className={styles.Actions}>
          <div className={styles.Buttons}>
            <Button
              label="Опрос"
              icon="addCircle"
              primary
              onClick={() => setSurveyModal(true)}
            />
          </div>

          <Avatar />
        </div>
      </div>

      {!surveyModal && (
        <Modal
          onClose={() => {
            console.log("пошел нахуй");
            setSurveyModal(false);
          }}
          title="Войти в профиль"
        >
          <Input icon="user" placeholder="email" />
          <Input icon="close" placeholder="password" />
        </Modal>
      )}
    </div>
  );
};
