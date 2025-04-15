"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import UFInc from "../Crud/Inc/UF";
import { getParamFromUrl } from "@/app/tools/helpers";

interface UFIncContainerProps {
    id: number;
    navigator: INavigator;
}

const UFIncContainer: React.FC<UFIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/uf"); // 27012025
    const handleError = () => { };

    return (
        <UFInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default UFIncContainer;