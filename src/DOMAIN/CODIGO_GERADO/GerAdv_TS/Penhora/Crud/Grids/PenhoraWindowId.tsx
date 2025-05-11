// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPenhora } from "../../Interfaces/interface.Penhora";
import { PenhoraService } from "../../Services/Penhora.service";
import { PenhoraApi } from "../../Apis/ApiPenhora";
import PenhoraWindow from "./PenhoraWindow";

interface PenhoraWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PenhoraWindowId: React.FC<PenhoraWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const penhoraService = useMemo(() => {
        return new PenhoraService(
            new PenhoraApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPenhora | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await penhoraService.fetchPenhoraById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PenhoraWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPenhora={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PenhoraWindowId;