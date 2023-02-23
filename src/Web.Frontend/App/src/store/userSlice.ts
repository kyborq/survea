import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from ".";

export type TUser = {
  name: string;
};

export interface IUserState {
  user?: TUser;
  logged: boolean;
}

const initialState: IUserState = {
  logged: false,
};

export const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    setUser: (state, action: PayloadAction<TUser>) => {
      state.user = action.payload;
    },
    setAuth: (state, action: PayloadAction<boolean>) => {
      state.logged = action.payload;
    },
    clearData: (state) => {
      state.logged = false;
      delete state.user;
    },
  },
});

export const { setUser, setAuth, clearData } = userSlice.actions;

export const selectLogged = (state: RootState) => state.user.logged;

export default userSlice.reducer;
