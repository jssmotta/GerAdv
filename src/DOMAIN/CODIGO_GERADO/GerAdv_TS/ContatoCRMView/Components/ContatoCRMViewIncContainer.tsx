"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ContatoCRMViewInc from "../Crud/Inc/ContatoCRMView";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ContatoCRMViewIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ContatoCRMViewIncContainer: React.FC<ContatoCRMViewIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/contatocrmview"); // 27012025
    const handleError = () => { };

    return (
        <ContatoCRMViewInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ContatoCRMViewIncContainer;