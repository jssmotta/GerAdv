// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProcessOutputEngine } from "../../Interfaces/interface.ProcessOutputEngine";
import { ProcessOutputEngineService } from "../../Services/ProcessOutputEngine.service";
import { ProcessOutputEngineApi } from "../../Apis/ApiProcessOutputEngine";
import ProcessOutputEngineWindow from "./ProcessOutputEngineWindow";

interface ProcessOutputEngineWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutputEngineWindowId: React.FC<ProcessOutputEngineWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const processoutputengineService = useMemo(() => {
        return new ProcessOutputEngineService(
            new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProcessOutputEngine | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await processoutputengineService.fetchProcessOutputEngineById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProcessOutputEngineWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProcessOutputEngine={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProcessOutputEngineWindowId;