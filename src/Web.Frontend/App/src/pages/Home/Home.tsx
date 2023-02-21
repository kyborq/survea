import React from "react";
import { Wrap } from "../../components/wrap/Wrap";
import { useAppSelector } from "../../store/hooks";

export const Home = () => {
  const isLogged = useAppSelector((state) => state.user.logged);

  return (
    <Wrap title="Главная" icon="home">
      {isLogged && <h1>fDSAFDSFD</h1>}
    </Wrap>
  );
};
