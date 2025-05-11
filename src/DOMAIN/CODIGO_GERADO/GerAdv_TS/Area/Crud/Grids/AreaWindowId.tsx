// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IArea } from "../../Interfaces/interface.Area";
import { AreaService } from "../../Services/Area.service";
import { AreaApi } from "../../Apis/ApiArea";
import AreaWindow from "./AreaWindow";

interface AreaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AreaWindowId: React.FC<AreaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const areaService = useMemo(() => {
        return new AreaService(
            new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IArea | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await areaService.fetchAreaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AreaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedArea={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AreaWindowId;