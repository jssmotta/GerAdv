// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProcessOutputRequest } from "../../Interfaces/interface.ProcessOutputRequest";
import { ProcessOutputRequestService } from "../../Services/ProcessOutputRequest.service";
import { ProcessOutputRequestApi } from "../../Apis/ApiProcessOutputRequest";
import ProcessOutputRequestWindow from "./ProcessOutputRequestWindow";

interface ProcessOutputRequestWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProcessOutputRequestWindowId: React.FC<ProcessOutputRequestWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const processoutputrequestService = useMemo(() => {
        return new ProcessOutputRequestService(
            new ProcessOutputRequestApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProcessOutputRequest | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await processoutputrequestService.fetchProcessOutputRequestById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProcessOutputRequestWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProcessOutputRequest={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProcessOutputRequestWindowId;