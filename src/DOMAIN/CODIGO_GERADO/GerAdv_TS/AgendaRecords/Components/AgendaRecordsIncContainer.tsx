"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AgendaRecordsInc from "../Crud/Inc/AgendaRecords";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AgendaRecordsIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AgendaRecordsIncContainer: React.FC<AgendaRecordsIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/agendarecords"); // 27012025
    const handleError = () => { };

    return (
        <AgendaRecordsInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AgendaRecordsIncContainer;