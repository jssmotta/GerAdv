import React from 'react';
import { render } from '@testing-library/react';
import RitoIncContainer from '@/app/GerAdv_TS/Rito/Components/RitoIncContainer';
// RitoIncContainer.test.tsx
// Mock do RitoInc
jest.mock('@/app/GerAdv_TS/Rito/Crud/Inc/Rito', () => (props: any) => (
<div data-testid='rito-inc-mock' {...props} />
));
describe('RitoIncContainer', () => {
  it('deve renderizar RitoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <RitoIncContainer id={id} navigator={mockNavigator} />
  );
  const ritoInc = getByTestId('rito-inc-mock');
  expect(ritoInc).toBeInTheDocument();
  expect(ritoInc.getAttribute('id')).toBe(id.toString());

});
});