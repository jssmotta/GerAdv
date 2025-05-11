// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IGUTTipo } from "../../Interfaces/interface.GUTTipo";
import { GUTTipoService } from "../../Services/GUTTipo.service";
import { GUTTipoApi } from "../../Apis/ApiGUTTipo";
import GUTTipoWindow from "./GUTTipoWindow";

interface GUTTipoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const GUTTipoWindowId: React.FC<GUTTipoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const guttipoService = useMemo(() => {
        return new GUTTipoService(
            new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IGUTTipo | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await guttipoService.fetchGUTTipoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <GUTTipoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedGUTTipo={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default GUTTipoWindowId;