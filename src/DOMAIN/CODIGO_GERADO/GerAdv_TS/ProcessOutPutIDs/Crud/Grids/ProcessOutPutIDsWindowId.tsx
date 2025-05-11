// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProcessOutPutIDs } from "../../Interfaces/interface.ProcessOutPutIDs";
import { ProcessOutPutIDsService } from "../../Services/ProcessOutPutIDs.service";
import { ProcessOutPutIDsApi } from "../../Apis/ApiProcessOutPutIDs";
import ProcessOutPutIDsWindow from "./ProcessOutPutIDsWindow";

interface ProcessOutPutIDsWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutPutIDsWindowId: React.FC<ProcessOutPutIDsWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const processoutputidsService = useMemo(() => {
        return new ProcessOutPutIDsService(
            new ProcessOutPutIDsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProcessOutPutIDs | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await processoutputidsService.fetchProcessOutPutIDsById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProcessOutPutIDsWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProcessOutPutIDs={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProcessOutPutIDsWindowId;