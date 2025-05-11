// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAuditor4K } from "../../Interfaces/interface.Auditor4K";
import { Auditor4KService } from "../../Services/Auditor4K.service";
import { Auditor4KApi } from "../../Apis/ApiAuditor4K";
import Auditor4KWindow from "./Auditor4KWindow";

interface Auditor4KWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const Auditor4KWindowId: React.FC<Auditor4KWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const auditor4kService = useMemo(() => {
        return new Auditor4KService(
            new Auditor4KApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAuditor4K | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await auditor4kService.fetchAuditor4KById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <Auditor4KWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAuditor4K={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default Auditor4KWindowId;