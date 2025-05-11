// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IParceriaProc } from "../../Interfaces/interface.ParceriaProc";
import { ParceriaProcService } from "../../Services/ParceriaProc.service";
import { ParceriaProcApi } from "../../Apis/ApiParceriaProc";
import ParceriaProcWindow from "./ParceriaProcWindow";

interface ParceriaProcWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ParceriaProcWindowId: React.FC<ParceriaProcWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const parceriaprocService = useMemo(() => {
        return new ParceriaProcService(
            new ParceriaProcApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IParceriaProc | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await parceriaprocService.fetchParceriaProcById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ParceriaProcWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedParceriaProc={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ParceriaProcWindowId;