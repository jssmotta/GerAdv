// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IGUTAtividades } from "../../Interfaces/interface.GUTAtividades";
import { GUTAtividadesService } from "../../Services/GUTAtividades.service";
import { GUTAtividadesApi } from "../../Apis/ApiGUTAtividades";
import GUTAtividadesWindow from "./GUTAtividadesWindow";

interface GUTAtividadesWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const GUTAtividadesWindowId: React.FC<GUTAtividadesWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const gutatividadesService = useMemo(() => {
        return new GUTAtividadesService(
            new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IGUTAtividades | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await gutatividadesService.fetchGUTAtividadesById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <GUTAtividadesWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedGUTAtividades={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default GUTAtividadesWindowId;