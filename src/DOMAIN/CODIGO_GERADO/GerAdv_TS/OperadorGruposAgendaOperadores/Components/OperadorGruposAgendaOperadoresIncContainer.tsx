"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OperadorGruposAgendaOperadoresInc from "../Crud/Inc/OperadorGruposAgendaOperadores";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OperadorGruposAgendaOperadoresIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OperadorGruposAgendaOperadoresIncContainer: React.FC<OperadorGruposAgendaOperadoresIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/operadorgruposagendaoperadores"); // 27012025
    const handleError = () => { };

    return (
        <OperadorGruposAgendaOperadoresInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OperadorGruposAgendaOperadoresIncContainer;