"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import SituacaoInc from "../Crud/Inc/Situacao";
import { getParamFromUrl } from "@/app/tools/helpers";

interface SituacaoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const SituacaoIncContainer: React.FC<SituacaoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/situacao"); // 27012025
    const handleError = () => { };

    return (
        <SituacaoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default SituacaoIncContainer;