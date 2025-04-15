"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AgendaQuemInc from "../Crud/Inc/AgendaQuem";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AgendaQuemIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AgendaQuemIncContainer: React.FC<AgendaQuemIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/agendaquem"); // 27012025
    const handleError = () => { };

    return (
        <AgendaQuemInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AgendaQuemIncContainer;