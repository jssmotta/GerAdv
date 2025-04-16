"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AgendaRepetirDiasInc from "../Crud/Inc/AgendaRepetirDias";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AgendaRepetirDiasIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AgendaRepetirDiasIncContainer: React.FC<AgendaRepetirDiasIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/agendarepetirdias"); // 27012025
    const handleError = () => { };

    return (
        <AgendaRepetirDiasInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AgendaRepetirDiasIncContainer;