"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import FuncaoInc from "../Crud/Inc/Funcao";
import { getParamFromUrl } from "@/app/tools/helpers";

interface FuncaoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const FuncaoIncContainer: React.FC<FuncaoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/funcao"); // 27012025
    const handleError = () => { };

    return (
        <FuncaoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default FuncaoIncContainer;