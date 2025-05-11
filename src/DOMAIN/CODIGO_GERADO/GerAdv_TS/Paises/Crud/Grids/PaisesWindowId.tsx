// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPaises } from "../../Interfaces/interface.Paises";
import { PaisesService } from "../../Services/Paises.service";
import { PaisesApi } from "../../Apis/ApiPaises";
import PaisesWindow from "./PaisesWindow";

interface PaisesWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PaisesWindowId: React.FC<PaisesWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const paisesService = useMemo(() => {
        return new PaisesService(
            new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPaises | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await paisesService.fetchPaisesById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PaisesWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPaises={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PaisesWindowId;