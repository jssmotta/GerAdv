// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IApenso } from "../../Interfaces/interface.Apenso";
import { ApensoService } from "../../Services/Apenso.service";
import { ApensoApi } from "../../Apis/ApiApenso";
import ApensoWindow from "./ApensoWindow";

interface ApensoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ApensoWindowId: React.FC<ApensoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const apensoService = useMemo(() => {
        return new ApensoService(
            new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IApenso | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await apensoService.fetchApensoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ApensoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedApenso={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ApensoWindowId;