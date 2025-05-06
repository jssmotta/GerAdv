"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import NEPalavrasChavesInc from "../Crud/Inc/NEPalavrasChaves";
import { getParamFromUrl } from "@/app/tools/helpers";

interface NEPalavrasChavesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const NEPalavrasChavesIncContainer: React.FC<NEPalavrasChavesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/nepalavraschaves"); // 27012025
    const handleError = () => { };

    return (
        <NEPalavrasChavesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default NEPalavrasChavesIncContainer;