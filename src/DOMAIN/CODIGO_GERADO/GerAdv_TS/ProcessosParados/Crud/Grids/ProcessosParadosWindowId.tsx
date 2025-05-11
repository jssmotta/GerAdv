// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProcessosParados } from "../../Interfaces/interface.ProcessosParados";
import { ProcessosParadosService } from "../../Services/ProcessosParados.service";
import { ProcessosParadosApi } from "../../Apis/ApiProcessosParados";
import ProcessosParadosWindow from "./ProcessosParadosWindow";

interface ProcessosParadosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessosParadosWindowId: React.FC<ProcessosParadosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const processosparadosService = useMemo(() => {
        return new ProcessosParadosService(
            new ProcessosParadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProcessosParados | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await processosparadosService.fetchProcessosParadosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProcessosParadosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProcessosParados={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProcessosParadosWindowId;