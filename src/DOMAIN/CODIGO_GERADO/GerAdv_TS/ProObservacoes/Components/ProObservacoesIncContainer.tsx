"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProObservacoesInc from "../Crud/Inc/ProObservacoes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProObservacoesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProObservacoesIncContainer: React.FC<ProObservacoesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/proobservacoes"); // 27012025
    const handleError = () => { };

    return (
        <ProObservacoesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProObservacoesIncContainer;