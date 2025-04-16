"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import SetorInc from "../Crud/Inc/Setor";
import { getParamFromUrl } from "@/app/tools/helpers";

interface SetorIncContainerProps {
    id: number;
    navigator: INavigator;
}

const SetorIncContainer: React.FC<SetorIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/setor"); // 27012025
    const handleError = () => { };

    return (
        <SetorInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default SetorIncContainer;