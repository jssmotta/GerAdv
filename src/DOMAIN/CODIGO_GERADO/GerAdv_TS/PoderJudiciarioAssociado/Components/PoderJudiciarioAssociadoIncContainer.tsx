"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import PoderJudiciarioAssociadoInc from "../Crud/Inc/PoderJudiciarioAssociado";
import { getParamFromUrl } from "@/app/tools/helpers";

interface PoderJudiciarioAssociadoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const PoderJudiciarioAssociadoIncContainer: React.FC<PoderJudiciarioAssociadoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/poderjudiciarioassociado"); // 27012025
    const handleError = () => { };

    return (
        <PoderJudiciarioAssociadoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default PoderJudiciarioAssociadoIncContainer;