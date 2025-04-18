﻿"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProProcuradoresInc from "../Crud/Inc/ProProcuradores";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProProcuradoresIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProProcuradoresIncContainer: React.FC<ProProcuradoresIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/proprocuradores"); // 27012025
    const handleError = () => { };

    return (
        <ProProcuradoresInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProProcuradoresIncContainer;