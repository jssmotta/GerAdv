"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import NENotasInc from "../Crud/Inc/NENotas";
import { getParamFromUrl } from "@/app/tools/helpers";

interface NENotasIncContainerProps {
    id: number;
    navigator: INavigator;
}

const NENotasIncContainer: React.FC<NENotasIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/nenotas"); // 27012025
    const handleError = () => { };

    return (
        <NENotasInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default NENotasIncContainer;