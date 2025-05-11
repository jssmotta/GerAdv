// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IRito } from "../../Interfaces/interface.Rito";
import { RitoService } from "../../Services/Rito.service";
import { RitoApi } from "../../Apis/ApiRito";
import RitoWindow from "./RitoWindow";

interface RitoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const RitoWindowId: React.FC<RitoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const ritoService = useMemo(() => {
        return new RitoService(
            new RitoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IRito | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await ritoService.fetchRitoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <RitoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedRito={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default RitoWindowId;