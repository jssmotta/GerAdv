﻿"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import HistoricoInc from "../Crud/Inc/Historico";
import { getParamFromUrl } from "@/app/tools/helpers";

interface HistoricoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const HistoricoIncContainer: React.FC<HistoricoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/historico"); // 27012025
    const handleError = () => { };

    return (
        <HistoricoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default HistoricoIncContainer;