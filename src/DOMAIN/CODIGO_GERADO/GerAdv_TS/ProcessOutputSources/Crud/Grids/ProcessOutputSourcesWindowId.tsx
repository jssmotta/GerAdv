// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProcessOutputSources } from "../../Interfaces/interface.ProcessOutputSources";
import { ProcessOutputSourcesService } from "../../Services/ProcessOutputSources.service";
import { ProcessOutputSourcesApi } from "../../Apis/ApiProcessOutputSources";
import ProcessOutputSourcesWindow from "./ProcessOutputSourcesWindow";

interface ProcessOutputSourcesWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutputSourcesWindowId: React.FC<ProcessOutputSourcesWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const processoutputsourcesService = useMemo(() => {
        return new ProcessOutputSourcesService(
            new ProcessOutputSourcesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProcessOutputSources | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await processoutputsourcesService.fetchProcessOutputSourcesById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProcessOutputSourcesWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProcessOutputSources={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProcessOutputSourcesWindowId;