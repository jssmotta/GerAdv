"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import LigacoesInc from "../Crud/Inc/Ligacoes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface LigacoesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const LigacoesIncContainer: React.FC<LigacoesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/ligacoes"); // 27012025
    const handleError = () => { };

    return (
        <LigacoesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default LigacoesIncContainer;