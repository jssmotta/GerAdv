"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import PrepostosInc from "../Crud/Inc/Prepostos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface PrepostosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const PrepostosIncContainer: React.FC<PrepostosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/prepostos"); // 27012025
    const handleError = () => { };

    return (
        <PrepostosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default PrepostosIncContainer;