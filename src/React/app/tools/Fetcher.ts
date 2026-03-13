'use client';
import axios from 'axios';

export function decodeBase64Token(token: string): string {
  return Buffer.from(token, 'base64').toString('utf-8');
}

export function encodeBase64Token(token: string): string {
  return Buffer.from(token, 'utf-8').toString('base64');
}

export const fetcher = async (key: string) => {
  const [url, token] = key.split('::');
  const response = await axios.get(url, {
    headers: {
      Authorization: `Bearer ${decodeBase64Token(token)}`,
      'Content-Type': 'application/json',
    },
  });

  if (response.status === 204) {
    return null;
  }
  if (response.status === 200) {
    return response.data;
  } else {
    throw new Error(`Unexpected response status: ${response.status}`);
  }
};
