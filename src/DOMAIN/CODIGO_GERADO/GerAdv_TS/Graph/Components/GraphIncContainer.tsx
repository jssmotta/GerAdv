"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import GraphInc from "../Crud/Inc/Graph";
import { getParamFromUrl } from "@/app/tools/helpers";

interface GraphIncContainerProps {
    id: number;
    navigator: INavigator;
}

const GraphIncContainer: React.FC<GraphIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/graph"); // 27012025
    const handleError = () => { };

    return (
        <GraphInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default GraphIncContainer;