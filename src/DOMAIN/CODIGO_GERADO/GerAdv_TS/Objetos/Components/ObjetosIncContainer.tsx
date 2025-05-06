"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ObjetosInc from "../Crud/Inc/Objetos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ObjetosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ObjetosIncContainer: React.FC<ObjetosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/objetos"); // 27012025
    const handleError = () => { };

    return (
        <ObjetosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ObjetosIncContainer;