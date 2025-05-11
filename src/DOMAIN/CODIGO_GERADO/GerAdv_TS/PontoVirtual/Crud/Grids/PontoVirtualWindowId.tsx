// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPontoVirtual } from "../../Interfaces/interface.PontoVirtual";
import { PontoVirtualService } from "../../Services/PontoVirtual.service";
import { PontoVirtualApi } from "../../Apis/ApiPontoVirtual";
import PontoVirtualWindow from "./PontoVirtualWindow";

interface PontoVirtualWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PontoVirtualWindowId: React.FC<PontoVirtualWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const pontovirtualService = useMemo(() => {
        return new PontoVirtualService(
            new PontoVirtualApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPontoVirtual | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await pontovirtualService.fetchPontoVirtualById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PontoVirtualWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPontoVirtual={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PontoVirtualWindowId;