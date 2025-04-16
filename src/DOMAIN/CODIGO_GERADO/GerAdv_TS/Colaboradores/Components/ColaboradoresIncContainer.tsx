"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ColaboradoresInc from "../Crud/Inc/Colaboradores";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ColaboradoresIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ColaboradoresIncContainer: React.FC<ColaboradoresIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/colaboradores"); // 27012025
    const handleError = () => { };

    return (
        <ColaboradoresInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ColaboradoresIncContainer;