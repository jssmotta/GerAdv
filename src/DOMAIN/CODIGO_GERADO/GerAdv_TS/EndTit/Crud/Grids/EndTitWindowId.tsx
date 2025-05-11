// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IEndTit } from "../../Interfaces/interface.EndTit";
import { EndTitService } from "../../Services/EndTit.service";
import { EndTitApi } from "../../Apis/ApiEndTit";
import EndTitWindow from "./EndTitWindow";

interface EndTitWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const EndTitWindowId: React.FC<EndTitWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const endtitService = useMemo(() => {
        return new EndTitService(
            new EndTitApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IEndTit | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await endtitService.fetchEndTitById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <EndTitWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedEndTit={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default EndTitWindowId;