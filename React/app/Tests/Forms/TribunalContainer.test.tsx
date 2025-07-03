import React from 'react';
import { render } from '@testing-library/react';
import TribunalIncContainer from '@/app/GerAdv_TS/Tribunal/Components/TribunalIncContainer';
// TribunalIncContainer.test.tsx
// Mock do TribunalInc
jest.mock('@/app/GerAdv_TS/Tribunal/Crud/Inc/Tribunal', () => (props: any) => (
<div data-testid='tribunal-inc-mock' {...props} />
));
describe('TribunalIncContainer', () => {
  it('deve renderizar TribunalInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TribunalIncContainer id={id} navigator={mockNavigator} />
  );
  const tribunalInc = getByTestId('tribunal-inc-mock');
  expect(tribunalInc).toBeInTheDocument();
  expect(tribunalInc.getAttribute('id')).toBe(id.toString());

});
});