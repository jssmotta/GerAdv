// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPrecatoria } from "../../Interfaces/interface.Precatoria";
import { PrecatoriaService } from "../../Services/Precatoria.service";
import { PrecatoriaApi } from "../../Apis/ApiPrecatoria";
import PrecatoriaWindow from "./PrecatoriaWindow";

interface PrecatoriaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PrecatoriaWindowId: React.FC<PrecatoriaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const precatoriaService = useMemo(() => {
        return new PrecatoriaService(
            new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPrecatoria | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await precatoriaService.fetchPrecatoriaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PrecatoriaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPrecatoria={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PrecatoriaWindowId;