﻿"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import Agenda2AgendaInc from "../Crud/Inc/Agenda2Agenda";
import { getParamFromUrl } from "@/app/tools/helpers";

interface Agenda2AgendaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const Agenda2AgendaIncContainer: React.FC<Agenda2AgendaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/agenda2agenda"); // 27012025
    const handleError = () => { };

    return (
        <Agenda2AgendaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default Agenda2AgendaIncContainer;