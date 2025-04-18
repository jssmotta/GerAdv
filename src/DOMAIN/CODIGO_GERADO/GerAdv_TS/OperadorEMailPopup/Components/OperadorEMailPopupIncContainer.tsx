﻿"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OperadorEMailPopupInc from "../Crud/Inc/OperadorEMailPopup";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OperadorEMailPopupIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OperadorEMailPopupIncContainer: React.FC<OperadorEMailPopupIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/operadoremailpopup"); // 27012025
    const handleError = () => { };

    return (
        <OperadorEMailPopupInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OperadorEMailPopupIncContainer;