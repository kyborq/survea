import React, { useState } from "react";
import { Input } from "../components/Input/Input";
import { Modal } from "../components/Modal/Modal";

type Props = {
  onClose?: () => void;
};

export const RegisterForm: React.FC<Props> = ({ onClose }) => {
  const handleAuth = () => {};

  return (
    <Modal
      onClose={onClose}
      onAccept={handleAuth}
      acceptTitle="Создать"
      onCancel={onClose}
      title="Создать аккаунт"
    >
      <Input icon="user" placeholder="email" />
      <Input icon="user" placeholder="name" />
      <Input icon="close" placeholder="password" />
      <Input icon="close" placeholder="repeat password" />
    </Modal>
  );
};
