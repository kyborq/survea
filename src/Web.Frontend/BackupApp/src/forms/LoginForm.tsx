import React, { useState } from "react";
import { Input } from "../components/Input/Input";
import { Modal } from "../components/Modal/Modal";

type Props = {
  onClose?: () => void;
};

export const LoginForm: React.FC<Props> = ({ onClose }) => {
  const handleAuth = () => {};

  return (
    <Modal
      onClose={onClose}
      onAccept={handleAuth}
      acceptTitle="Войти"
      onCancel={onClose}
      title="Войти в профиль"
    >
      <Input icon="user" placeholder="email" />
      <Input icon="close" placeholder="password" />
    </Modal>
  );
};
