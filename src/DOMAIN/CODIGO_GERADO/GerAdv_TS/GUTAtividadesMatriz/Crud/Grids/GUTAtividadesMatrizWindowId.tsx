// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IGUTAtividadesMatriz } from "../../Interfaces/interface.GUTAtividadesMatriz";
import { GUTAtividadesMatrizService } from "../../Services/GUTAtividadesMatriz.service";
import { GUTAtividadesMatrizApi } from "../../Apis/ApiGUTAtividadesMatriz";
import GUTAtividadesMatrizWindow from "./GUTAtividadesMatrizWindow";

interface GUTAtividadesMatrizWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const GUTAtividadesMatrizWindowId: React.FC<GUTAtividadesMatrizWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const gutatividadesmatrizService = useMemo(() => {
        return new GUTAtividadesMatrizService(
            new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IGUTAtividadesMatriz | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await gutatividadesmatrizService.fetchGUTAtividadesMatrizById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <GUTAtividadesMatrizWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedGUTAtividadesMatriz={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default GUTAtividadesMatrizWindowId;