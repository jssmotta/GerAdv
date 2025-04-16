"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AcaoInc from "../Crud/Inc/Acao";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AcaoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AcaoIncContainer: React.FC<AcaoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/acao"); // 27012025
    const handleError = () => { };

    return (
        <AcaoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AcaoIncContainer;