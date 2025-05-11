"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import EndTitInc from "../Crud/Inc/EndTit";
import { getParamFromUrl } from "@/app/tools/helpers";

interface EndTitIncContainerProps {
    id: number;
    navigator: INavigator;
}

const EndTitIncContainer: React.FC<EndTitIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/endtit"); // 27012025
    const handleError = () => { };

    return (
        <EndTitInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default EndTitIncContainer;