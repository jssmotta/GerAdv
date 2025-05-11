"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import StatusAndamentoInc from "../Crud/Inc/StatusAndamento";
import { getParamFromUrl } from "@/app/tools/helpers";

interface StatusAndamentoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const StatusAndamentoIncContainer: React.FC<StatusAndamentoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/statusandamento"); // 27012025
    const handleError = () => { };

    return (
        <StatusAndamentoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default StatusAndamentoIncContainer;